using System;
using Memo.Core.CQRS;

namespace Memo.Api.Application.Command
{
    public class DeleteWordCommand : ICommand
    {
        public DeleteWordCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}