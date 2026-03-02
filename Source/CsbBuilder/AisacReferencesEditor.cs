using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CsbBuilder
{
    public class AisacReferencesEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (provider != null)
            {
                IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                if (editorService != null && MainForm.AisacTreeView != null)
                {
                    List<string> currentList = value as List<string> ?? new List<string>();
                    List<string> editList = new List<string>(currentList);

                    using (AisacCollectionEditorForm form = new AisacCollectionEditorForm(editList, MainForm.AisacTreeView))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            return form.References;
                        }
                    }
                }
            }

            return value;
        }
    }
}
