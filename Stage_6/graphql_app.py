from starlette_graphene3 import GraphQLApp
from database_models import *

databases: dict[str, Database] = {}


def _get_database(database_name: str) -> Database:
    try:
        return databases[database_name]
    except KeyError:
        raise GraphQLError(f"Cannot find database '{database_name}'")

def _get_table(database_name: str, table_id: int) -> Table:
    table = _get_database(database_name).resolve_get_table_by_id(None, table_id)
    if table is None:
        raise GraphQLError(f"Database '{database_name}' doesn't contain table #{table_id}")
    return table

def _get_entry(database_name: str, table_id: int, entry_id: int) -> Entry:
    entry = _get_table(database_name, table_id).resolve_get_entry_by_id(None, entry_id)
    if entry is None:
        raise GraphQLError(f"Table #{table_id} in database '{database_name}' doesn't contain entry #{entry_id}")
    return entry

class Query(graphene.ObjectType):
    databases = graphene.List(Database, required=True)
    get_database_by_name = graphene.Field(Database, database_name=graphene.String(required=True))

    def resolve_databases(root, info):
        return databases.values()

    def resolve_get_database_by_name(root, info, database_name: str):
        try:
            return _get_database(database_name)
        except GraphQLError:
            return None

class CreateDatabase(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)

    database = graphene.Field(Database, required=True)

    def mutate(root, info, database_name: str):
        if database_name in databases:
            raise GraphQLError(f"Database '{database_name}' already exists")
        database = Database(name=database_name)
        databases[database_name] = database
        return CreateDatabase(database=database)

class DeleteDatabase(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)

    true = graphene.Boolean(required=True)

    def mutate(root, info, database_name: str):
        _get_database(database_name)
        del databases[database_name]
        return DeleteDatabase(true=True)

class InputAttribute(graphene.InputObjectType):
    name: str = graphene.String(required=True)
    type: Type = graphene.Field(Type, required=True)
    r_min: typing.Optional[int] = graphene.Int()
    r_max: typing.Optional[int] = graphene.Int()
    g_min: typing.Optional[int] = graphene.Int()
    g_max: typing.Optional[int] = graphene.Int()
    b_min: typing.Optional[int] = graphene.Int()
    b_max: typing.Optional[int] = graphene.Int()

class CreateTable(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)
        table_name = graphene.String(required=True)
        attributes = graphene.List(InputAttribute, required=True)

    table = graphene.Field(Table, required=True)

    def mutate(root, info, database_name: str, table_name: str, attributes: list[InputAttribute]):
        database = _get_database(database_name)
        return CreateTable(table=database.add_table(table_name, [Attribute(**attribute.__dict__) for attribute in attributes]))

class DeleteTable(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)
        table_id = graphene.Int(required=True)

    true = graphene.Boolean(required=True)

    def mutate(root, info, database_name: str, table_id: int):
        _get_table(database_name, table_id)
        _get_database(database_name).remove_table(table_id)
        return DeleteTable(true=True)

class InputValue(graphene.InputObjectType):
    integer: int = graphene.BigInt()
    real: Decimal = graphene.Float()
    string: str = graphene.String()
    r: int = graphene.Int()
    g: int = graphene.Int()
    b: int = graphene.Int()

    def to_value(self):
        if self.integer is not None:
            assert self.real is self.string is self.r is self.g is self.b is None
            return IntegerValue(integer=self.integer)
        if self.real is not None:
            assert self.integer is self.string is self.r is self.g is self.b is None
            return RealValue(real=self.real)
        if self.string is not None:
            assert self.integer is self.real is self.r is self.g is self.b is None
            return StringValue(string=self.string)
        if self.r is not None and self.g is not None and self.b is not None:
            assert self.integer is self.real is self.string is None
            return ColorValue(r=self.r, g=self.g, b=self.b)
        raise GraphQLError(f'Cannot parse InputValue{self.__dict__}')

class CreateEntry(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)
        table_id = graphene.Int(required=True)
        values = graphene.List(InputValue, required=True)

    entry = graphene.Field(Entry, required=True)

    def mutate(root, info, database_name: str, table_id: int, values: list[InputValue]):
        try:
            return CreateEntry(entry=_get_table(database_name, table_id).add_entry([value.to_value() for value in values]))
        except ValueError as err:
            raise GraphQLError(str(err))

class DeleteEntry(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)
        table_id = graphene.Int(required=True)
        entry_id = graphene.Int(required=True)

    true = graphene.Boolean(required=True)

    def mutate(root, info, database_name: str, table_id: int, entry_id: int):
        _get_entry(database_name, table_id, entry_id)
        _get_table(database_name, table_id).remove_entry(entry_id)
        return DeleteTable(true=True)

class UpdateCellValue(graphene.Mutation):
    class Arguments:
        database_name = graphene.String(required=True)
        table_id = graphene.Int(required=True)
        entry_id = graphene.Int(required=True)
        attribute_id = graphene.Int(required=True)
        value = graphene.Argument(InputValue, required=True)

    entry = graphene.Field(Entry, required=True)

    def mutate(root, info, database_name: str, table_id: int, entry_id: int, attribute_id: int, value: InputValue):
        table = _get_table(database_name, table_id)
        entry = _get_entry(database_name, table_id, entry_id)
        if attribute_id >= len(table.attributes):
            raise GraphQLError(f"Table #{table_id} in database '{database_name}' doesn't contain attribute #{attribute_id}")
        try:
            table.attributes[attribute_id].check_value(value)
        except ValueError as err:
            raise GraphQLError(str(err))
        entry.values[attribute_id] = value.to_value()
        return UpdateCellValue(entry=entry)

class Mutation(graphene.ObjectType):
    create_database = CreateDatabase.Field()
    delete_database = DeleteDatabase.Field()
    create_table = CreateTable.Field()
    delete_table = DeleteTable.Field()
    create_entry = CreateEntry.Field()
    delete_entry = DeleteEntry.Field()
    #update_cell_value = UpdateCellValue.Field()

schema = graphene.Schema(query=Query, mutation=Mutation)
graphql_app = GraphQLApp(schema=schema)