#region License
// The MIT License (MIT)
// Copyright (c) 2015 Jo�o Sim�es
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
#endregion
namespace SimplePersistence.Model.Security
{
    using System;

    /// <summary>
    /// EntityType that represents one specific user claim
    /// </summary>
    /// <typeparam name="TUserKey">The user key type</typeparam>
    /// <typeparam name="TClaimType">The claim type</typeparam>
    public class UserClaim<TUserKey, TClaimType> : Entity<int>
        where TClaimType : IClaimType
        where TUserKey : IEquatable<TUserKey>
    {
        /// <summary>
        /// User Id for the user who owns this claim
        /// </summary>
        public virtual TUserKey UserId { get; set; }

        /// <summary>
        /// Claim type
        /// </summary>
        public virtual TClaimType ClaimType { get; set; }

        /// <summary>
        /// Claim value
        /// </summary>
        public virtual string ClaimValue { get; set; }
    }

    /// <summary>
    /// EntityType that represents one specific user claim
    /// </summary>
    public class UserClaim<TUserKey> : UserClaim<TUserKey, ClaimType>
        where TUserKey : IEquatable<TUserKey>
    {

    }

    /// <summary>
    /// EntityType that represents one specific user claim
    /// </summary>
    public class UserClaim : UserClaim<string, ClaimType>
    {
        
    }
}