using System.Collections.Generic;
using AbpDemo.Roles.Dto;

namespace AbpDemo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}