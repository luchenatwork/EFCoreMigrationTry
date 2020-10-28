connection_string=$1
migration_version=$2
if [ "$connection_string" ]
then
    echo "export connectionString=$connection_string"
    export connectionString="$connection_string"
fi
if [ $migration_version ]
then
    echo "dotnet ef database update $migration_version --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp"
    dotnet ef database update $migration_version --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp
else
    echo "dotnet ef database update --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp"
    dotnet ef database update --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp
fi