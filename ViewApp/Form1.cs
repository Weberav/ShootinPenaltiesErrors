using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ViewApp.Core;
using ViewApp.Models;

namespace ViewApp
{
    public partial class Form1 : Form
    {
        private static string? _filePath = string.Empty;
        private static XmlDocument? _xDoc;

        public List<Person>? Persons { get; set; }
        public List<Team>? Teams { get; set; }
        public List<Race>? Races { get; set; }
        public List<string>? UniqueRaces { get; set; }
        public List<Category>? Categories { get; set; }
        public Dictionary<string,List<Person>>? PersonsByRace { get; set; }
        public List<Person>? PersonsWithErorrs { get; set; }

        XmlModule xmlModule = new XmlModule();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Загрузка файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            //Возвращаем строку в которой находится файл
            (_filePath,_xDoc) = xmlModule.LoadFile();
            //Присваиваем ссылку на файл с которым работаем
            xmlModule.filepath = _filePath;

            //Получаем челиков команды и гонки
            (Persons,Teams) = xmlModule.GetListOfPersons(_xDoc);
            Races = xmlModule.GetListOfRaces(_xDoc);
            PersonsByRace = xmlModule.FillRace(_xDoc, Persons, Races,Teams);

            //Получаем уникальные названия гонок
            UniqueRaces = Races.Select(x => x.Name).Distinct().ToList();

            

            DisplayRaces();
            DisplayTeams();
            DisplayPersons();
        }
        /// <summary>
        /// Отображение гонок
        /// </summary>
        private void DisplayRaces()
        {
            dgv_RacesList.RowHeadersVisible = false;
            dgv_RacesList.DataSource = UniqueRaces.Select(x => new { Гонка = x }).ToList();

            dgv_RacesList.ClearSelection();
        }
        /// <summary>
        /// Отображение команд
        /// </summary>
        private void DisplayTeams()
        {
            var bindingList = new BindingList<Team>(Teams);
            BindingSource source = new BindingSource(bindingList, null);
            dgv_TeamsList.DataSource = source;

            dgv_TeamsList.RowHeadersVisible = false;

            dgv_TeamsList.Columns["Id"].Visible = false;


        }
        /// <summary>
        /// Отображение участников
        /// </summary>
        private void DisplayPersons()
        {
            //Привязка данных к DGV
            var bindingList = new BindingList<Person>(Persons);
            BindingSource source = new BindingSource(bindingList, null);
            dgv_PersonList.DataSource = source;

            dgv_PersonList.RowHeadersVisible = false;


            dgv_PersonList.Columns["Id"].Visible = false;
            dgv_PersonList.Columns["TeamId"].Visible = false;
            dgv_PersonList.Columns["IsTeam"].Visible = false;

            dgv_PersonList.Columns["Bib"].HeaderText = "Bib";
            dgv_PersonList.Columns["LastName"].HeaderText = "Фамилия";
            dgv_PersonList.Columns["Name"].HeaderText = "Имя";
            dgv_PersonList.Columns["ClassId"].HeaderText = "Категория";
            dgv_PersonList.Columns["Shootings"].HeaderText = "Промахи";
            dgv_PersonList.Columns["PenaltyLaps"].HeaderText = "Штрафные";

            dgv_PersonList.Columns["Shootings"].Visible = false;
            dgv_PersonList.Columns["PenaltyLaps"].Visible = false;

            dgv_PersonList.ClearSelection();
        }
        /// <summary>
        /// Показывает список с ошибками
        /// </summary>
        private void DisplayPersonsWithErrors()
        {
            var bindingList = new BindingList<Person>(PersonsWithErorrs);
            BindingSource source = new BindingSource(bindingList, null);
            dgv_PersonList.DataSource = source;

            dgv_PersonList.RowHeadersVisible = false;

            dgv_PersonList.Columns["Id"].Visible = false;
            dgv_PersonList.Columns["TeamId"].Visible = false;
            dgv_PersonList.Columns["IsTeam"].Visible = false;

            dgv_PersonList.Columns["Id"].HeaderText = "Id";
            dgv_PersonList.Columns["LastName"].HeaderText = "Фамилия";
            dgv_PersonList.Columns["Name"].HeaderText = "Имя";
            dgv_PersonList.Columns["ClassId"].HeaderText = "Категория";
            dgv_PersonList.Columns["Shootings"].HeaderText = "Промахи";
            dgv_PersonList.Columns["PenaltyLaps"].HeaderText = "Штрафные";
            dgv_PersonList.Columns["Shootings"].Visible = true;
            dgv_PersonList.Columns["PenaltyLaps"].Visible = true;

            dgv_PersonList.ClearSelection();
        }
        
        /// <summary>
        /// Кнопка которая проверяет ошибки и отдает в ДГВ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_СheckErrors_Click(object sender, EventArgs e)
        {
            PersonsWithErorrs = xmlModule.CheckErrors(PersonsByRace);
            DisplayPersonsWithErrors();
            DisplayRacesWithErrors();
        }

        private void DisplayRacesWithErrors()
        {
            
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
