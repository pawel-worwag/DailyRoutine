﻿using Identity.Api.Common;
using Identity.Application.Common.Enums;
using Identity.Application.Common.Interfaces;
using Identity.Domain.ValueObjects;
using Identity.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/identity-management-old/users")]
    [ApiController]
    [ProducesDefaultContentType]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get list of registered users
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Application.Users.GetUsers.Response>> GetUsersList(int take = 50, int skip = 0)
        {
            return Ok(await _mediator.Send(new Application.Users.GetUsers.GetUsersRequest
            {
                Take = take,
                Skip = skip
            }));
        }

        /// <summary>
        /// Get user details
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpGet("{guid}")]
        public async Task<ActionResult<Application.Users.GetUserDetails.Response>> GetUserDetails(Guid guid)
        {
            return Ok(await _mediator.Send(new Application.Users.GetUserDetails.GetUserDetailsRequest
            {
                Guid = guid
            }));
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddNewUser(Models.Users.AddNewUserDto dto)
        {
            var guid = await _mediator.Send(new Application.Users.AddUser.AddUserRequest
            {
                NormalizedEmail = dto.NormalizedEmail,
                Roles = dto.Roles.Select(p=>new NormalizedName(p)).ToList(),
                PersonalClaims = dto.PersonalClaims.Select(p => new Application.Users.AddUser.Claim
                {
                    Type = p.Type,
                    Value = p.Value
                }).ToList(),
                TimeZone = dto.TimeZone,
                Culture = dto.Culture
            });
            
            var url = this.Url.Action("GetUserDetails", new { guid = guid });
            return Created(new Uri(url!, UriKind.Relative), null);
        }

        /// <summary>
        /// Update user data
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPut("{guid}")]
        public async Task<ActionResult> UpdateUser(Guid guid, Models.Users.UpdateUserDto dto)
        {
            await _mediator.Send(new Application.Users.UpdateUser.UpdateUserRequest
            {
                Guid = guid,
                NormalizedEmail = dto.NormalizedEmail,
                Roles = dto.Roles.Select(p=>new NormalizedName(p)).ToList(),
                PersonalClaims = dto.PersonalClaims.Select(p => new Application.Users.UpdateUser.Claim
                {
                    Type = p.Type,
                    Value = p.Value
                }).ToList(),
                TimeZone = dto.TimeZone,
                Culture = dto.Culture
            });
            return Ok();
        }

        /// <summary>
        /// Reject all recovery tokens
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete("{guid}/recovery-tokens")]
        public async Task<ActionResult> RejectAllRecoveryTokens(Guid guid)
        {
            await _mediator.Send(new Application.Users.RejectRecoveryTokens.RejectRecoveryTokensRequest
            {
                Guid = guid
            });
            return Ok();
        }
        
        
        /// <summary>
        /// [TO-DO] Send Welcome-Email to user
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpPost("{guid}/send-welcome-email")]
        public async Task<ActionResult> SendWelcomeEmail(Guid guid)
        {
            await _mediator.Send(new Application.Users.SendWelcomeEmail.SendWelcomeEmailRequest()
            {
                Guid = guid
            });
            //only test
            //await _mailBus.SendMailAsync(EmailType.HELLO,"pl",new List<string>(){guid.ToString()},new Dictionary<string, string>());
            return Ok();
        }
    }
}
