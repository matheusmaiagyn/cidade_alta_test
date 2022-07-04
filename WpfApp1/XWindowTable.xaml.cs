using CidadeAltaProject.Controllers;
using System.Text.RegularExpressions;
using CidadeAltaProject.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
  /// <summary>
  /// Lógica interna para WindowTable.xaml
  /// </summary>
  public partial class XWindowTable : Window
  {
    CriminalCode[] criminalCode;
    CriminalCode[] criminalCodeAux;
    int criminalCodeTot;
    private int _Page = 0;

    public XWindowTable()
    {
      InitializeComponent();
      criminalCodeAux = new CriminalCode[0];

      TxtSearchID.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(TxtSearchID_GotKeyboardFocus);
      TxtSearchID.Foreground = Brushes.Gray;
      TxtSearchID.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(TxtSearchID_LostKeyboardFocus);

      foreach (var c in dataGrid.Columns)
      {
        DropDown.Items.Add(c.Header);
      }
      DropDown.SelectedItem = "ID";

      AtualizarLista();
    }

    private void BtnAtualizar_Click(object sender, RoutedEventArgs e)
    {
      AtualizarLista();
    }

    private void AtualizarLista(CriminalCode[] pCriminalCode = null)
    {
      using (var criminalServices = new XCriminalCodeController(null))
      {
        criminalCode = pCriminalCode == null ? criminalServices.GetCriminalCodesPage(_Page.ToString()) : pCriminalCode;
        criminalCodeTot = criminalServices.GetAllCriminalCodes().Count();
        dataGrid.ItemsSource = criminalCode;
        var json = JsonConvert.SerializeObject(criminalCode);
        var c = JsonConvert.DeserializeObject<List<CriminalCode>>(json);
        criminalCodeAux = c.ToArray();
      }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      XMainWindow.Instancia.Show();
      this.Close();
    }

    private void BtnNovo_Click(object sender, RoutedEventArgs e)
    {
      while (dataGrid.Items.Count == 12)
      {
        _Page += 12;
        AtualizarLista();
      }
      var criminalCodeList = criminalCode.ToList();
      criminalCodeList.Add(new CriminalCode()
      {
        ID = criminalCodeTot + 1,
        Description = string.Empty,
        CreateDate = DateTime.Now,
        CreateUserID = XMainWindow.Instancia.UsuarioLogado.ID,
      });
      criminalCode = criminalCodeList.ToArray();
      criminalCodeTot += 1;
      dataGrid.ItemsSource = criminalCode;
      dataGrid.Items.Refresh();
    }

    private void BtnSalvar_Click(object sender, RoutedEventArgs e)
    {
      using (var criminalServices = new XCriminalCodeController(null))
      {
        foreach (var code in criminalCode)
        {
          if (criminalCodeAux.Any(c => c.ID == code.ID))
          {
            var codeAux = criminalCodeAux.FirstOrDefault(a => a.ID == code.ID);
            if (JsonConvert.SerializeObject(codeAux) != JsonConvert.SerializeObject(code))
            {
              code.UpdateUserID = XMainWindow.Instancia.UsuarioLogado.ID;
              code.UpdateDate = DateTime.Now;
              criminalServices.Save(code);
            }
          }
          else if (!criminalCodeAux.Contains(code))
          {
            criminalServices.Save(code);
          }
        }
        var json = JsonConvert.SerializeObject(criminalCode);
        var c = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CriminalCode>>(json);
        criminalCodeAux = c.ToArray();
      }
      AtualizarLista();
    }

    private void BtnExcluir_Click(object sender, RoutedEventArgs e)
    {
      bool staged = false;
      using (var criminalServices = new XCriminalCodeController(null))
      {
        foreach (var sel in dataGrid.SelectedItems)
        {
          CriminalCode code = sel as CriminalCode;
          if (code != null)
            criminalServices.Excluir(code);
          var c = criminalCode.ToList();
          c.Remove(code);
          criminalCode = c.ToArray();
          if (!criminalCodeAux.Any(c => c.ID == code.ID))
          {
            staged = true;
          }
        }
      }
      criminalCodeTot -= 1;
      if (staged)
        dataGrid.ItemsSource = criminalCode;
      else
        AtualizarLista(criminalCode);
    }

    private void TxtSearchID_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender is TextBox)
      {
        if (((TextBox)sender).Foreground == Brushes.Gray)
        {
          ((TextBox)sender).Text = "";
          ((TextBox)sender).Foreground = Brushes.Black;
        }
      }
    }

    private void TxtSearchID_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender is TextBox)
      {
        if (((TextBox)sender).Text.Trim().Equals(""))
        {
          ((TextBox)sender).Foreground = Brushes.Gray;
          ((TextBox)sender).Text = String.Format("Procurar por {0}", DropDown.SelectedItem.ToString());
        }
      }
    }

    private void TxtSearchID_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (TxtSearchID.Text.Contains("Procurar por"))
        return;
      else if (TxtSearchID.Text == "")
        return;
      using (var criminalServices = new XCriminalCodeController(null))
      {
        var criminalList = new List<CriminalCode>();
        criminalList.AddRange(criminalServices.SearchBy(TxtSearchID.Text, DropDown.SelectedItem.ToString()));

        AtualizarLista(criminalList.ToArray());
      }
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      using (var criminalServices = new XCriminalCodeController(null))
      {
        var criminalList = new List<CriminalCode>();
        criminalList.AddRange(criminalServices.FilterBy(DropDown.SelectedItem.ToString()));

        AtualizarLista(criminalList.ToArray());
      }
      TxtSearchID.Text = String.Format("Procurar por {0}", DropDown.SelectedItem.ToString());
    }

    private void BtnAvancar_Click(object sender, RoutedEventArgs e)
    {
      _Page += 12;
      AtualizarLista();
    }

    private void BtnVoltar_Click(object sender, RoutedEventArgs e)
    {
      if (_Page <= 0)
        return;
      _Page -= 12;
      AtualizarLista();
    }
  }
}
