namespace Black.Service
{
    public interface IPermissionValidateService
    {
        bool ValidateUserPermission(int idUser, string[] constPermission);
        bool ValidateUserPermission(int idUser, string constPermission);
    }
}
