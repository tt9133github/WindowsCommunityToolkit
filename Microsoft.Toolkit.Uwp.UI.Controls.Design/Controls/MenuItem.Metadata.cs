// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;

using Microsoft.Toolkit.Uwp.UI.Controls.Design.Properties;

#if VS_DESIGNER_PROCESS_ISOLATION
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.PropertyEditing;
#endif

namespace Microsoft.Toolkit.Uwp.UI.Controls.Design
{
    internal class MenuItemMetadata : AttributeTableBuilder
    {
        public MenuItemMetadata()
            : base()
        {
            AddCallback(typeof(MenuItem),
                b =>
                {
                    b.AddCustomAttributes(nameof(MenuItem.Header),
                        new PropertyOrderAttribute(PropertyOrder.Early),
                        new CategoryAttribute(Resources.CategoryCommon)
                    );
                    b.AddCustomAttributes(nameof(MenuItem.IsOpened),
                        new CategoryAttribute(Resources.CategoryCommon)
                    );
                    b.AddCustomAttributes(nameof(MenuItem.HeaderTemplate),
                        new EditorBrowsableAttribute(EditorBrowsableState.Advanced),
                        new CategoryAttribute(Resources.CategoryCommon)
                    );
                    b.AddCustomAttributes(nameof(MenuItem.Items),
                        new PropertyOrderAttribute(PropertyOrder.Early),
                        new CategoryAttribute(Resources.CategoryCommon),
                        //The following is necessary because this is a collection of an abstract type, so we help
                        //the designer with populating supported types that can be added to the collection
                        new NewItemTypesAttribute(new System.Type[] {
                            typeof(MenuItem),
                        }),
                        new AlternateContentPropertyAttribute()
                    );

                    b.AddCustomAttributes(new ToolboxCategoryAttribute(ToolboxCategoryPaths.Toolkit, false));
                    b.AddCustomAttributes(new ToolboxBrowsableAttribute(false));
                }
            );
        }
    }
}
