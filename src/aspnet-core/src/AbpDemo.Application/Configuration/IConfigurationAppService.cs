using System.Threading.Tasks;
using AbpDemo.Configuration.Dto;

namespace AbpDemo.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
