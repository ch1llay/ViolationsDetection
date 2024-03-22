using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Interfaces;

public interface ICrudController<T, TId>
{
    Task<ActionResult<T>> Add(T model);
    Task<ActionResult<T>> GetById(TId id);

    Task<ActionResult<T>> Update(T model)
    {
        throw new NotImplementedException();
    }

    Task<ActionResult<T>> Delete(TId id);
}
