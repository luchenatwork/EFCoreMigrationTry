connection_string=$1
if [ "$connection_string" ]
then
    echo "export connectionString=$connection_string"
    export connectionString="$connection_string"
fi
echo "dotnet ef migrations remove --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp"
dotnet ef migrations remove --project ../EFCoreMigrationTry.DataMigration --startup-project ../EFCoreMigrationTry.ConsoleApp