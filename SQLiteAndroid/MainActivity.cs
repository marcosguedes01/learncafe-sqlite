using Android.App;
using Android.Widget;
using Android.OS;
using SQLite.Net.Async;
using System.Threading.Tasks;
using Banco.Helpers;

namespace SQLiteAndroid
{
    [Activity(Label = "SQLiteAndroid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += Button_Click;
        }

        SQLiteAsyncConnection conn;
        private async void Button_Click(object sender, System.EventArgs e)
        {
            EditText edt = FindViewById<EditText>(Resource.Id.editText1);
            ListView lst = FindViewById<ListView>(Resource.Id.listView1);

            conn = await AndroidLib.Helpers.Util.GetConexaoAsync();

            await Util.CriarPessoa(conn);

            var query = Util.ObterPessoas(conn, edt.Text);

            var l = await query.ToListAsync();

            ArrayAdapter arr = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, l.ToArray());
            
            lst.Adapter = arr;
        }
    }
}

