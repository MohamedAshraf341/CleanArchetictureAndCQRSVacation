namespace Vacation.Application.Helper
{
    public static class Permissions
    {
        public static List<string> GeneratePermissionsList(string module)
        {
            return new List<string>()
            {
                $"Permissions.{module}.View",
                $"Permissions.{module}.Create",
                $"Permissions.{module}.Edit",
                $"Permissions.{module}.Delete"
            };
        }

        public static List<string> GenerateAllPermissions()
        {
            var allPermissions = new List<string>();

            var modules = Enum.GetValues(typeof(Modules));

            foreach (var module in modules)
                allPermissions.AddRange(GeneratePermissionsList(module.ToString()));

            return allPermissions;
        }

        public static class VacationModule
        {
            public const string View = "Permissions.Vacation.View";
            public const string Create = "Permissions.Vacation.Create";
            public const string Edit = "Permissions.Vacation.Edit";
            public const string Delete = "Permissions.Vacation.Delete";
        }
    }
}
