using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.Exceptions;

public class AuthorizationProblemDetails : ProblemDetails
{
	public override string ToString() => JsonConvert.SerializeObject(this);
}
