using Core.Ldap.Console._03;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Core.Ldap
{
    public class AdUserController
    {
        /// <summary>
        /// Property of sAM account name
        /// </summary>
        public const string SamAccountNameProperty = "sAMAccountName";

        /// <summary>
        /// Property of name CN
        /// </summary>
        public const string CanonicalNameProperty = "CN";

        /// <summary>
        /// Property of SID
        /// </summary>
        public const string SidProperty = "objectSid";

        /// <summary>
        /// Property for First Name
        /// </summary>
        public const string FirstNameProperty = "givenName";

        /// <summary>
        /// Property for last name
        /// </summary>
        public const string LastNameProperty = "sn";

        /// <summary>
        /// Property to get AD group membership
        /// </summary>
        public const string MemberOfProperty = "memberOf";

        /// <summary>
        /// Property for direct reports
        /// </summary>
        public const string DirectReportsProperty = "directReports";

        /// <summary>
        /// Property for logoff info
        /// </summary>
        public const string LastLogoffProperty = "lastLogoff";

        /// <summary>
        /// Property for street address info
        /// </summary>
        public const string StreetAddressProperty = "streesAddress";

        /// <summary>
        /// Property for last logon info
        /// </summary>
        public const string LastLogonProperty = "lastLogon";

        /// <summary>
        /// Property for admin count
        /// </summary>
        public const string AdminCountProperty = "adminCount";

        //配置以下四个参数，开放389端口。
        string domainName = "192.168.231.230";
        string domainRoot = "whzh";
        string domainUser = "Administrator";
        string domainPass = "Chemical.ai";
        public void Sync()
        {
            try
            {
                //连接域

                DirectoryEntry domain = new DirectoryEntry();
                domain.Path = string.Format("LDAP://{0}", domainName);
                domain.Username = domainUser;
                domain.Password = domainPass;
                domain.AuthenticationType = AuthenticationTypes.Secure;
                domain.RefreshCache();

                DirectoryEntry entryOU = domain.Children.Find("OU=" + domainRoot);
                DirectorySearcher mySearcher = new DirectorySearcher(entryOU, "(objectClass=user)"); //查询组织单位(objectclass=organizationalUnit)

                SearchResultCollection searchResultCollection = mySearcher.FindAll();

                List<ADUser> users = new List<ADUser>();

                foreach (SearchResult searchResult in searchResultCollection)
                {
                    var user = new ADUser();

                    //Set CN if avail
                    if (searchResult.Properties[CanonicalNameProperty].Count > 0) user.CN = searchResult.Properties[CanonicalNameProperty][0].ToString();

                    //Set samaccount if available
                    if (searchResult.Properties[SamAccountNameProperty].Count > 0) user.SamAccountName = searchResult.Properties[SamAccountNameProperty][0].ToString();

                    //Set first name info
                    if (searchResult.Properties[FirstNameProperty].Count > 0) user.FirstName = searchResult.Properties[FirstNameProperty][0].ToString();

                    //Sets last name info
                    if (searchResult.Properties[LastNameProperty].Count > 0) user.LastName = searchResult.Properties[LastNameProperty][0].ToString();

                    //Sets member of info
                    if (searchResult.Properties[MemberOfProperty].Count > 0) user.MemberOf = searchResult.Properties[MemberOfProperty][0].ToString();

                    //Sets direct reports info if there
                    if (searchResult.Properties[DirectReportsProperty].Count > 0) user.DirectReports = searchResult.Properties[DirectReportsProperty][0].ToString();

                    //Sets street address info
                    if (searchResult.Properties[StreetAddressProperty].Count > 0) user.StreetAddress = searchResult.Properties[StreetAddressProperty][0].ToString();

                    //Sets last logoff info
                    if (searchResult.Properties[LastLogoffProperty].Count > 0) user.LastLogoff = searchResult.Properties[LastLogoffProperty][0].ToString();

                    //Sets last logon info
                    if (searchResult.Properties[LastLogonProperty].Count > 0) user.LastLogon = Convert.ToString(DateTime.FromFileTime((long)searchResult.Properties[LastLogonProperty][0]));

                    //Gets admin count
                    if (searchResult.Properties[AdminCountProperty].Count > 0) user.AdminCount = searchResult.Properties[AdminCountProperty][0].ToString();

                    //Get SID if available
                    if (searchResult.Properties[SidProperty].Count > 0) user.SID = (new SecurityIdentifier((byte[])searchResult.Properties[SidProperty][0], 0).Value);

                    //Add use to users list
                    users.Add(user);
                }

                DirectoryEntry root = mySearcher.SearchRoot;   //查找根OU

                if (root.Properties.Contains("ou") && root.Properties.Contains("objectGUID"))
                {
                    string rootOuName = root.Properties["ou"][0].ToString();
                    byte[] bGUID = root.Properties["objectGUID"][0] as byte[];
                    Guid id = new Guid(bGUID);
                    SyncSubOU(root, id);
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       

        

        private void SyncSubOU(DirectoryEntry entry, Guid parentId)
        {
            foreach (DirectoryEntry subEntry in entry.Children)
            {
                string entrySchemaClsName = subEntry.SchemaClassName;

                string[] arr = subEntry.Name.Split('=');
                string categoryStr = arr[0];
                string nameStr = arr[1];
                byte[] bGUID = subEntry.Properties["objectGUID"][0] as byte[];
                Guid id = new Guid(bGUID);

            }
        }

    }
}
