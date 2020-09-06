using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Associate.Behaviors
{
    public class EntryIsUniqueValidationBehavior : Behavior<Entry>
    {
        public static readonly BindableProperty CollectionProperty = BindableProperty.Create("Collection", typeof(IEnumerable<ITeam>), typeof(EntryIsUniqueValidationBehavior), null);
        public static readonly BindableProperty ItemSpacingProperty = BindableProperty.Create("ItemSpacing", typeof(string), typeof(EntryIsUniqueValidationBehavior), "2");
        private Entry entry;
        public string Name { get; set; }

        public string ItemSpacing
        {
            get { return (string)GetValue(ItemSpacingProperty); }
            set { SetValue(ItemSpacingProperty, value); }
        }


        public IEnumerable<ITeam> Collection
        {
            get { return (IEnumerable<ITeam>)GetValue(CollectionProperty); }
            set { SetValue(CollectionProperty, value); }
        }

      
        protected override void OnAttachedTo(Entry entry)
        
        {
          
            this.entry = entry;
            entry.Unfocused += OnEntryUnfocused;
            entry.BindingContextChanged += BindingContextChanged;
            
            base.OnAttachedTo(entry);
        }

        private void BindingContextChanged(object sender,EventArgs eventArgs)
        {
            var a = sender;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Unfocused -= OnEntryUnfocused;
            entry.BindingContextChanged -= BindingContextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryUnfocused(object sender, FocusEventArgs e)
        {
            int timesOccured = 0;
            
            foreach (var item in this.Collection)
            {
                if (this.entry.Text == item.Name)
                {
                    timesOccured++;
                    
                }
            }
            if (timesOccured>1)
            {
                this.entry.BackgroundColor = Color.Red;
               this.entry.Focus() ;
            }
            
        }




    }
}
