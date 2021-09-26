using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        [Route("signUp")]
        public IActionResult SignUp(SignUpRequest request)
        {
            //call firebase
            //save to persistence

            //new
            //{
            //    UserId = Guid.NewGuid(),
            //    FirebaseId = Response.Id,
            //    Email = 
            //}

            return Ok(new
            {
                UserId = Guid.NewGuid(),
                IdToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjdiODcxMTIzNzU0MjdkNjU3ZjVlMjVjYTAxZDU2NWU1OTJhMjMxZGIiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vY2FtcGdyb3VuZGFwcC1iaXQiLCJhdWQiOiJjYW1wZ3JvdW5kYXBwLWJpdCIsImF1dGhfdGltZSI6MTYzMjY0MzMxNiwidXNlcl9pZCI6InhUT3VkMTdrOUtlT0UyNEc4Yjl0WHV5VGJzNTIiLCJzdWIiOiJ4VE91ZDE3azlLZU9FMjRHOGI5dFh1eVRiczUyIiwiaWF0IjoxNjMyNjQzMzE2LCJleHAiOjE2MzI2NDY5MTYsImVtYWlsIjoidGVzdGFzQHRlc3Rhcy5jb20iLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsImZpcmViYXNlIjp7ImlkZW50aXRpZXMiOnsiZW1haWwiOlsidGVzdGFzQHRlc3Rhcy5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJwYXNzd29yZCJ9fQ.oBqWWRYhVsFAHNJFpXJfB_WguE5VQJSLZzwUHUre9eAdJ37DR46DkWjJ8wxdp9NqF2MJu_gQxfgRDgUsf90HH4jcNiBg_rCuAzeiolKrb6YjQb_8QIr0KCe97u4gr_W57cidaeb5oU7ft48tKLwsDJSZ_jtqX5Vi_we7ZTSVo44cHQVtBYPC_-IY2sxIvMOLf8NA9zCfkv6oPNf3jzLJJHKLnfzWAVujGv_hpzdfZRLR5i5Hg0iG-GsxXN9t3JUe2w7Bi5M5p1iK86wiBZD73ox1UFYnnz7zE-wZ7GwpW6LAwzl3O0dECW7dKpwYgPlO23EAajyNY3n26vuVUEHivA"
            });
        }

        [HttpPost]
        [Route("signIn")]
        public IActionResult SignIn(SignUpRequest request)
        {
            return Ok(new
            {
                UserId = Guid.NewGuid(),
                IdToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjdiODcxMTIzNzU0MjdkNjU3ZjVlMjVjYTAxZDU2NWU1OTJhMjMxZGIiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vY2FtcGdyb3VuZGFwcC1iaXQiLCJhdWQiOiJjYW1wZ3JvdW5kYXBwLWJpdCIsImF1dGhfdGltZSI6MTYzMjY0MzMxNiwidXNlcl9pZCI6InhUT3VkMTdrOUtlT0UyNEc4Yjl0WHV5VGJzNTIiLCJzdWIiOiJ4VE91ZDE3azlLZU9FMjRHOGI5dFh1eVRiczUyIiwiaWF0IjoxNjMyNjQzMzE2LCJleHAiOjE2MzI2NDY5MTYsImVtYWlsIjoidGVzdGFzQHRlc3Rhcy5jb20iLCJlbWFpbF92ZXJpZmllZCI6ZmFsc2UsImZpcmViYXNlIjp7ImlkZW50aXRpZXMiOnsiZW1haWwiOlsidGVzdGFzQHRlc3Rhcy5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJwYXNzd29yZCJ9fQ.oBqWWRYhVsFAHNJFpXJfB_WguE5VQJSLZzwUHUre9eAdJ37DR46DkWjJ8wxdp9NqF2MJu_gQxfgRDgUsf90HH4jcNiBg_rCuAzeiolKrb6YjQb_8QIr0KCe97u4gr_W57cidaeb5oU7ft48tKLwsDJSZ_jtqX5Vi_we7ZTSVo44cHQVtBYPC_-IY2sxIvMOLf8NA9zCfkv6oPNf3jzLJJHKLnfzWAVujGv_hpzdfZRLR5i5Hg0iG-GsxXN9t3JUe2w7Bi5M5p1iK86wiBZD73ox1UFYnnz7zE-wZ7GwpW6LAwzl3O0dECW7dKpwYgPlO23EAajyNY3n26vuVUEHivA"
            });
        }

        public class SignUpRequest
        {
            public string Username{ get; set; }

            public string Password{ get; set; }
        }
    }
}
