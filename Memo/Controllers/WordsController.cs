using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Memo.Api.Application;
using Memo.Api.Application.Command;
using Memo.Api.Application.Query;
using Memo.Datacontract;
using Memo.Domain;
using Memo.Domain.WordAggregate;
using Memo.Domain.WordsModel;
using Memo.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WordsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public WordsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public async Task<IActionResult> GetMany([FromQuery] QueryDto dtoQuery)
        {
            var query = new PagedWordQuery(dtoQuery.Page, dtoQuery.NumberPerPage);

            var result = await _dispatcher.DispatchQuery<PagedWordQuery, List<Word>>(query);
            
            var dto = AutoMapper.Mapper.Map<IEnumerable<WordDtoSend>>(result);

            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WordDtoSend>> Get(Guid id, CancellationToken cancellationToken = default)
        {
            var command = new OneWordQuery(id);
            var word = await _dispatcher.DispatchQuery<OneWordQuery, Word>(command);
            if (word is null)
                NotFound();

            var dto = AutoMapper.Mapper.Map<WordDtoSend>(word);

            return Ok(dto);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Post([FromBody] WordDtoForCreate word)
        {
            if (word == null)
                return BadRequest();

            var command = new CreateWordCommand(word);
            var result = await _dispatcher.DispatchCommand(command);

            return result.IsSuccess ? Ok() : StatusCode(500);
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult> Validate([FromBody] IEnumerable<WordDtoValid> wordsToValidate)
        {
            if (wordsToValidate == null)
                return BadRequest();

            var command = new ValidateWordCommand(wordsToValidate.ToList());
            var result = await _dispatcher.DispatchCommand(command);

            return result.IsSuccess ? Ok() : StatusCode(500);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] WordDtoForCreate word, Guid id)
        {
            if (word == null)
                BadRequest();

            var command = new UpdateWordCommand(word, id);
            var result = await _dispatcher.DispatchCommand(command);

            return result.IsSuccess ? Ok() : StatusCode(500);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteWordCommand(id);
            var result = await _dispatcher.DispatchCommand(command);
            return result.IsSuccess ? Ok() : StatusCode(500);
        }
    }
}