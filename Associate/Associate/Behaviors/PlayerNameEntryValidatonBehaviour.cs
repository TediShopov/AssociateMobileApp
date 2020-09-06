using Associate.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Associate.Behaviors
{
   public class PlayerNameEntryValidatonBehaviour:Behavior<Entry>
    {



        public static BindableProperty CollectionProperty = BindableProperty.Create("Collection", typeof(IEnumerable<ITeam>), typeof(PlayerNameEntryValidatonBehaviour), null);

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
               
                foreach (var member in item.Members)
                {
                    if (this.entry.Text== member.Name)
                    {
                        timesOccured++;
                    }
                    
                }
            }
            if (timesOccured > 1)
            {
                this.entry.BackgroundColor = Color.DeepPink;
                

            }

        }




    }
}
