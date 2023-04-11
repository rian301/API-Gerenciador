namespace Black.Domain.QuerieResult
{
    public class GetAllPermissionsByIdUserProfileQueryResult
    {
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public string ConstName { get; set; }
        public bool Checked { get; set; }
    }
}
