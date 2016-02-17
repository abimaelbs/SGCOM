using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace SGCOM.Api.Controllers
{
    /*Cross-origin resource sharing (CORS)(ou compartilhamento de recursos de origem cruzada) 
      É uma especificação de uma tecnologia de navegadores que define meios para um servidor 
      permitir que seus recursos sejam acessados por uma página web de um domínio diferente.
      Esse tipo de acesso seria de outra forma negado pela same origin policy. 
      CORS define um meio pelo qual um navegador e um servidor web podem interagir para determinar 
      se devem ou não utilizar/permitir requisições cross-origem.
    */
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple =false)]
    public class MyCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private CorsPolicy _policy;

        public MyCorsPolicyAttribute()
        {
            // Criando CORS policy
            _policy = new CorsPolicy
            {
                AllowAnyOrigin = true,                
                AllowAnyHeader = true,
                AllowAnyMethod = true
            };

            // Add allowed origins            
            _policy.Origins.Add("*");
            _policy.Headers.Add("*");
            _policy.Methods.Add("*");

        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}