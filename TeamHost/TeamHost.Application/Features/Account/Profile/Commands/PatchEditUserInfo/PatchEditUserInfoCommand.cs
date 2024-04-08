using MediatR;
using TeamHost.Shared.Requests.Account.PatchEditUserInfo;

namespace TeamHost.Application.Features.Account.Profile.Commands.PatchEditUserInfo;

public class PatchEditUserInfoCommand(PatchEditUserInfoRequest request) 
    : PatchEditUserInfoRequest(request), IRequest;