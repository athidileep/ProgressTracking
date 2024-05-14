using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public interface ISecretManager
    {
        Task<Dictionary<string, object>> GetSecrets(string secretname);
    }
}
