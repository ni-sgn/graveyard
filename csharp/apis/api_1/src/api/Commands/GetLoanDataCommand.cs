using MediatR;

namespace api.Commands;

public sealed record GetLoanDataCommand ( 
    int applicationId
) : IRequest<int>;
