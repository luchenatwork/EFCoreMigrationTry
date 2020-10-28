migration_version=$1
connection_string=$2
if [ ! $migration_version ]
then
    echo "The name of migration is not provided"
    exit 1
fi
if [ "$connection_string" ]
then
    echo "export connectionString=$connection_string"
    export connectionString="$connection_string"
fi
echo "dotnet ef migrations add $migration_version --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp"
dotnet ef migrations add $migration_version --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp