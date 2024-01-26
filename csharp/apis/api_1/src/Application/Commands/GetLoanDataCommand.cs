using MediatR;

namespace api.Commands;

public sealed record GetLoanDataCommand ( 
    int applicationId
) : IRequest<int>;

public sealed class GetLoanDataCommandHandler : 
    IRequestHandler<GetLoanDataCommand, int> {

        public Task<int> Handle(GetLoanDataCommand command, CancellationToken cancellationToken){
             
            return Task.Run( () => 3 + 3 );
        }

}

public sealed class LoanDataValidations
{
    
}