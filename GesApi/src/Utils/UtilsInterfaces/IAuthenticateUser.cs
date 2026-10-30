using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GesApi.src.Utils.UtilsInterfaces {
    public interface IAuthenticateUser {
        public Task<string> CreateAccessToken(long id, int profileTypeId, int addHours);
    }
}