// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING
// WITHOUT LIMITATION ANY IMPLIED WARRANTIES OR CONDITIONS OF
// TITLE, FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABLITY OR
// NON-INFRINGEMENT.
// See the Apache 2 License for the specific language governing
// permissions and limitations under the License.

using JetBrains.Annotations;
using Microsoft.Data.Relational.Utilities;

namespace Microsoft.Data.Relational.Model
{
    // TODO: Use this instead of the DefaultValue, DefaultSql pair.

    public struct DefaultConstraint
    {
        private object _valueOrSql;
        private bool _isSql;

        public static DefaultConstraint Value([NotNull] object value)
        {
            Check.NotNull(value, "value");

            return new DefaultConstraint { _valueOrSql = value, _isSql = false };
        }

        public static DefaultConstraint Sql([NotNull] string sql)
        {
            Check.NotEmpty(sql, "sql");

            return new DefaultConstraint { _valueOrSql = sql, _isSql = true };
        }

        public bool IsNull
        {
            get { return _valueOrSql == null; }
        }

        public object GetValue()
        {
            return _isSql ? null : _valueOrSql;
        }

        public string GetSql()
        {
            return _isSql ? (string)_valueOrSql : null;
        }
    }
}