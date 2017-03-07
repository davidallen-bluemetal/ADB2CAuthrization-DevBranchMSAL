﻿//----------------------------------------------------------------------
//
// Copyright (c) Microsoft Corporation.
// All rights reserved.
//
// This code is licensed under the MIT License.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files(the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and / or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions :
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Internal.OAuth2;

namespace Microsoft.Identity.Client.Internal.Requests
{
    public class OnBehalfOfRequest : BaseRequest
    {
        public OnBehalfOfRequest(AuthenticationRequestParameters authenticationRequestParameters)
            : base(authenticationRequestParameters)
        {
            if (authenticationRequestParameters.UserAssertion == null)
            {
                throw new ArgumentNullException(nameof(authenticationRequestParameters.UserAssertion));
            }

            authenticationRequestParameters.User = new User {DisplayableId = authenticationRequestParameters.UserAssertion.UserName};
        }

        protected override async Task SendTokenRequestAsync()
        {
            await base.SendTokenRequestAsync().ConfigureAwait(false);
        }

        protected override void SetAdditionalRequestParameters(OAuth2Client client)
        {
            client.AddBodyParameter(OAuth2Parameter.GrantType,
                AuthenticationRequestParameters.UserAssertion.AssertionType);
            client.AddBodyParameter(OAuth2Parameter.Assertion, AuthenticationRequestParameters.UserAssertion.Assertion);
            client.AddBodyParameter(OAuth2Parameter.RequestedTokenUse, OAuth2RequestedTokenUse.OnBehalfOf);

            //TODO To request id_token in response
            //requestParameters[OAuth2Parameter.Scope] = OAuth2Value.ScopeOpenId;
        }
    }
}