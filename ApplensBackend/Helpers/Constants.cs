﻿// <copyright file="Constants.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>

using System;

namespace AppLensV3.Helpers
{
    /// <summary>
    /// Github constants.
    /// </summary>
    internal static class GithubConstants
    {
        internal const string RawFileHeaderMediaType = "application/vnd.github.VERSION.raw";
        internal const string TemplatePath = "https://raw.githubusercontent.com/Azure/Azure-AppServices-Diagnostics/master/data/templates/{filename}.csx";
        internal const string SourceFilePathFormat = "https://api.github.com/repos/{0}/{1}/contents/{2}/{2}.csx?ref={3}&access_token={4}";
        internal const string MetadataFilePathFormat = "https://api.github.com/repos/{0}/{1}/contents/{2}/metadata.json?ref={3}&access_token={4}";
        internal const string ConfigPathFormat = "https://api.github.com/repos/{0}/{1}/contents/{2}/package.json?ref={3}&access_token={4}";
        internal const string ResourceConfigFormat = "https://api.github.com/repos/{0}/{1}/contents/resourceConfig/config.json?ref={2}&access_token={3}";
    }

    /// <summary>
    /// Kusto constants.
    /// </summary>
    internal static class KustoConstants
    {
        internal static readonly TimeSpan DefaultTimeGrain = TimeSpan.FromMinutes(5);
        internal const string MicrosoftTenantAuthorityUrl = "https://login.windows.net/microsoft.com";
        internal const int TokenRefreshIntervalInMs = 10 * 60 * 1000;   // 10 minutes
        internal const string DefaultKustoEndpoint = "https://wawswus.kusto.windows.net";
        internal const string KustoApiEndpointFormat = "https://{0}.kusto.windows.net:443/v1/rest/query";
    }

    internal static class GraphConstants
    {
        internal static readonly TimeSpan DefaultTimeGrain = TimeSpan.FromMinutes(5);
        internal const string MicrosoftTenantAuthorityUrl = "https://login.windows.net/microsoft.com";
        internal const int TokenRefreshIntervalInMs = 10 * 60 * 1000;   // 10 minutes
        internal const string DefaultGraphEndpoint = "https://graph.microsoft.com/";
        internal const string GraphApiEndpointFormat = "https://graph.microsoft.com/v1.0/{0}";
        internal const string GraphUserApiEndpointFormat = "https://graph.microsoft.com/v1.0/users/{0}@microsoft.com";
        internal const string GraphUserImageApiEndpointFormat = "https://graph.microsoft.com/v1.0/users/{0}@microsoft.com/photo/$value";
    }

    internal static class SelfHelpConstants
    {
        internal const string RawFileHeaderMediaType = "application/vnd.github.VERSION.raw";
        internal const string ArticleTemplatePath = "https://api.github.com/repos/Azure/SelfHelpContent/contents/articles/{0}?ref=master&access_token={1}";
    }

    internal static class InsightsConstants
    {
        internal const string SiteResourceTypeName = "sites";
        internal const string HostingEnvironmentResourceTypeName = "hostingEnvironments";
    }
}
