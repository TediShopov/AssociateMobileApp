using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Associate.Behaviors
{
    public class TeamEntryIsUniqueValidationBehavior : Behavior<Entry>
    {
       

        public static  BindableProperty CollectionProperty = BindableProperty.Create("Collection", typeof(IEnumerable<ITeam>), typeof(TeamEntryIsUniqueValidationBehavior), null);
        
        private Entry entry;
        public IEnumerable<ITeam> Collection
        {
            get { return (IEnumerable<ITeam>)GetValue(CollectionProperty); }
            set { SetValue(CollectionProperty, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        
        {
          
            this.entry = entry;
            entry.Unfocused += OnEntryUnfocused;
          
            
            base.OnAttachedTo(entry);
        }

        

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Unfocused -= OnEntryUnfocused;
          
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
               
            }
            
        }




    }
}
