#region Copyright

// <copyright file="CheckboxElement.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace CrossUI.Touch.Dialog.Elements
{
    public class CheckboxElement : ValueElement<bool>
    {
        private static readonly NSString Key = new NSString("CheckboxElement");

        public string Group { get; set; }

        public CheckboxElement() : this("")
        {
        }

        public CheckboxElement(string caption) : base(caption)
        {
        }

        public CheckboxElement(string caption, bool value) : base(caption)
        {
            Value = value;
        }

        public CheckboxElement(string caption, bool value, string group) : this(caption, value)
        {
            Group = group;
        }

        private void SetCellCheckmark(UITableViewCell cell)
        {
            cell.Accessory = Value ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
        }

        protected override UITableViewCell GetCellImpl(UITableView tv)
        {
            var cell = tv.DequeueReusableCell(Key);
            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, Key);
            }
            SetCellCheckmark(cell);

            return cell;
        }

        public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
        {
            Value = !Value;
            var cell = tableView.CellAt(path);
            SetCellCheckmark(cell);
            base.Selected(dvc, tableView, path);
        }

        protected override void UpdateDetailDisplay(UITableViewCell cell)
        {
            SetCellCheckmark(cell);
        }
    }
}