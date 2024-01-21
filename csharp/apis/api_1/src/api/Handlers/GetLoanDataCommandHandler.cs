namespace api.Handlers;

using MediatR;
using api.Commands;

internal sealed class GetLoanDataCommandHandler : 
    IRequestHandler<GetLoanDataCommand, int> {

        public Task<int> Handle(GetLoanDataCommand command, CancellationToken cancellationToken){
             
            return Task.Run( () => 3 + 3 );
        }

}