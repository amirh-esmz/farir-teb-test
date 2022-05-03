
namespace Application.Services.Base
{
    public class BaseApiService
    {
        protected readonly IHttpContextAccessor httpContextAccessor;
        protected readonly IWebHostEnvironment environment;
        protected readonly IMapper mapper;

        public BaseApiService(IWebHostEnvironment environment, 
            IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.environment = environment;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }

        protected CancellationToken IsRequestCancelled => 
            httpContextAccessor?.HttpContext?.RequestAborted ?? default(CancellationToken);
    }
}
