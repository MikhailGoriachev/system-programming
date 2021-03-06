#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentalLibrary.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="CarRental")]
	public partial class CarRentalDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBrand(Brand instance);
    partial void UpdateBrand(Brand instance);
    partial void DeleteBrand(Brand instance);
    partial void InsertCar(Car instance);
    partial void UpdateCar(Car instance);
    partial void DeleteCar(Car instance);
    partial void InsertClient(Client instance);
    partial void UpdateClient(Client instance);
    partial void DeleteClient(Client instance);
    partial void InsertColor(Color instance);
    partial void UpdateColor(Color instance);
    partial void DeleteColor(Color instance);
    partial void InsertRental(Rental instance);
    partial void UpdateRental(Rental instance);
    partial void DeleteRental(Rental instance);
    #endregion
		
		public CarRentalDataContext() : 
				base(global::CarRentalLibrary.Properties.Settings.Default.CarRentalConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CarRentalDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarRentalDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarRentalDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CarRentalDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Brand> Brands
		{
			get
			{
				return this.GetTable<Brand>();
			}
		}
		
		public System.Data.Linq.Table<Car> Cars
		{
			get
			{
				return this.GetTable<Car>();
			}
		}
		
		public System.Data.Linq.Table<Client> Clients
		{
			get
			{
				return this.GetTable<Client>();
			}
		}
		
		public System.Data.Linq.Table<Color> Colors
		{
			get
			{
				return this.GetTable<Color>();
			}
		}
		
		public System.Data.Linq.Table<Rental> Rentals
		{
			get
			{
				return this.GetTable<Rental>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Brands")]
	public partial class Brand : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Brand1;
		
		private EntitySet<Car> _Cars;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnBrand1Changing(string value);
    partial void OnBrand1Changed();
    #endregion
		
		public Brand()
		{
			this._Cars = new EntitySet<Car>(new Action<Car>(this.attach_Cars), new Action<Car>(this.detach_Cars));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Brand", Storage="_Brand1", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string Brand1
		{
			get
			{
				return this._Brand1;
			}
			set
			{
				if ((this._Brand1 != value))
				{
					this.OnBrand1Changing(value);
					this.SendPropertyChanging();
					this._Brand1 = value;
					this.SendPropertyChanged("Brand1");
					this.OnBrand1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Brand_Car", Storage="_Cars", ThisKey="Id", OtherKey="IdBrand")]
		public EntitySet<Car> Cars
		{
			get
			{
				return this._Cars;
			}
			set
			{
				this._Cars.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.Brand = this;
		}
		
		private void detach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.Brand = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cars")]
	public partial class Car : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _IdBrand;
		
		private int _IdColor;
		
		private string _Plate;
		
		private int _YearManuf;
		
		private int _InshurancePay;
		
		private int _Rental;
		
		private EntitySet<Rental> _Rentals;
		
		private EntityRef<Brand> _Brand;
		
		private EntityRef<Color> _Color;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnIdBrandChanging(int value);
    partial void OnIdBrandChanged();
    partial void OnIdColorChanging(int value);
    partial void OnIdColorChanged();
    partial void OnPlateChanging(string value);
    partial void OnPlateChanged();
    partial void OnYearManufChanging(int value);
    partial void OnYearManufChanged();
    partial void OnInshurancePayChanging(int value);
    partial void OnInshurancePayChanged();
    partial void OnRentalChanging(int value);
    partial void OnRentalChanged();
    #endregion
		
		public Car()
		{
			this._Rentals = new EntitySet<Rental>(new Action<Rental>(this.attach_Rentals), new Action<Rental>(this.detach_Rentals));
			this._Brand = default(EntityRef<Brand>);
			this._Color = default(EntityRef<Color>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdBrand", DbType="Int NOT NULL")]
		public int IdBrand
		{
			get
			{
				return this._IdBrand;
			}
			set
			{
				if ((this._IdBrand != value))
				{
					if (this._Brand.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdBrandChanging(value);
					this.SendPropertyChanging();
					this._IdBrand = value;
					this.SendPropertyChanged("IdBrand");
					this.OnIdBrandChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdColor", DbType="Int NOT NULL")]
		public int IdColor
		{
			get
			{
				return this._IdColor;
			}
			set
			{
				if ((this._IdColor != value))
				{
					if (this._Color.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdColorChanging(value);
					this.SendPropertyChanging();
					this._IdColor = value;
					this.SendPropertyChanged("IdColor");
					this.OnIdColorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Plate", DbType="NVarChar(9) NOT NULL", CanBeNull=false)]
		public string Plate
		{
			get
			{
				return this._Plate;
			}
			set
			{
				if ((this._Plate != value))
				{
					this.OnPlateChanging(value);
					this.SendPropertyChanging();
					this._Plate = value;
					this.SendPropertyChanged("Plate");
					this.OnPlateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YearManuf", DbType="Int NOT NULL")]
		public int YearManuf
		{
			get
			{
				return this._YearManuf;
			}
			set
			{
				if ((this._YearManuf != value))
				{
					this.OnYearManufChanging(value);
					this.SendPropertyChanging();
					this._YearManuf = value;
					this.SendPropertyChanged("YearManuf");
					this.OnYearManufChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InshurancePay", DbType="Int NOT NULL")]
		public int InshurancePay
		{
			get
			{
				return this._InshurancePay;
			}
			set
			{
				if ((this._InshurancePay != value))
				{
					this.OnInshurancePayChanging(value);
					this.SendPropertyChanging();
					this._InshurancePay = value;
					this.SendPropertyChanged("InshurancePay");
					this.OnInshurancePayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rental", DbType="Int NOT NULL")]
		public int Rental
		{
			get
			{
				return this._Rental;
			}
			set
			{
				if ((this._Rental != value))
				{
					this.OnRentalChanging(value);
					this.SendPropertyChanging();
					this._Rental = value;
					this.SendPropertyChanged("Rental");
					this.OnRentalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_Rental", Storage="_Rentals", ThisKey="Id", OtherKey="IdCar")]
		public EntitySet<Rental> Rentals
		{
			get
			{
				return this._Rentals;
			}
			set
			{
				this._Rentals.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Brand_Car", Storage="_Brand", ThisKey="IdBrand", OtherKey="Id", IsForeignKey=true)]
		public Brand Brand
		{
			get
			{
				return this._Brand.Entity;
			}
			set
			{
				Brand previousValue = this._Brand.Entity;
				if (((previousValue != value) 
							|| (this._Brand.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Brand.Entity = null;
						previousValue.Cars.Remove(this);
					}
					this._Brand.Entity = value;
					if ((value != null))
					{
						value.Cars.Add(this);
						this._IdBrand = value.Id;
					}
					else
					{
						this._IdBrand = default(int);
					}
					this.SendPropertyChanged("Brand");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Color_Car", Storage="_Color", ThisKey="IdColor", OtherKey="Id", IsForeignKey=true)]
		public Color Color
		{
			get
			{
				return this._Color.Entity;
			}
			set
			{
				Color previousValue = this._Color.Entity;
				if (((previousValue != value) 
							|| (this._Color.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Color.Entity = null;
						previousValue.Cars.Remove(this);
					}
					this._Color.Entity = value;
					if ((value != null))
					{
						value.Cars.Add(this);
						this._IdColor = value.Id;
					}
					else
					{
						this._IdColor = default(int);
					}
					this.SendPropertyChanged("Color");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Rentals(Rental entity)
		{
			this.SendPropertyChanging();
			entity.Car = this;
		}
		
		private void detach_Rentals(Rental entity)
		{
			this.SendPropertyChanging();
			entity.Car = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Clients")]
	public partial class Client : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Surname;
		
		private string _Name;
		
		private string _Patronymic;
		
		private string _Passport;
		
		private EntitySet<Rental> _Rentals;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnSurnameChanging(string value);
    partial void OnSurnameChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPatronymicChanging(string value);
    partial void OnPatronymicChanged();
    partial void OnPassportChanging(string value);
    partial void OnPassportChanged();
    #endregion
		
		public Client()
		{
			this._Rentals = new EntitySet<Rental>(new Action<Rental>(this.attach_Rentals), new Action<Rental>(this.detach_Rentals));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Surname", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string Surname
		{
			get
			{
				return this._Surname;
			}
			set
			{
				if ((this._Surname != value))
				{
					this.OnSurnameChanging(value);
					this.SendPropertyChanging();
					this._Surname = value;
					this.SendPropertyChanged("Surname");
					this.OnSurnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Patronymic", DbType="NVarChar(80) NOT NULL", CanBeNull=false)]
		public string Patronymic
		{
			get
			{
				return this._Patronymic;
			}
			set
			{
				if ((this._Patronymic != value))
				{
					this.OnPatronymicChanging(value);
					this.SendPropertyChanging();
					this._Patronymic = value;
					this.SendPropertyChanged("Patronymic");
					this.OnPatronymicChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Passport", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
		public string Passport
		{
			get
			{
				return this._Passport;
			}
			set
			{
				if ((this._Passport != value))
				{
					this.OnPassportChanging(value);
					this.SendPropertyChanging();
					this._Passport = value;
					this.SendPropertyChanged("Passport");
					this.OnPassportChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Client_Rental", Storage="_Rentals", ThisKey="Id", OtherKey="IdClient")]
		public EntitySet<Rental> Rentals
		{
			get
			{
				return this._Rentals;
			}
			set
			{
				this._Rentals.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Rentals(Rental entity)
		{
			this.SendPropertyChanging();
			entity.Client = this;
		}
		
		private void detach_Rentals(Rental entity)
		{
			this.SendPropertyChanging();
			entity.Client = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Colors")]
	public partial class Color : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Color1;
		
		private EntitySet<Car> _Cars;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnColor1Changing(string value);
    partial void OnColor1Changed();
    #endregion
		
		public Color()
		{
			this._Cars = new EntitySet<Car>(new Action<Car>(this.attach_Cars), new Action<Car>(this.detach_Cars));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Color", Storage="_Color1", DbType="NVarChar(40) NOT NULL", CanBeNull=false)]
		public string Color1
		{
			get
			{
				return this._Color1;
			}
			set
			{
				if ((this._Color1 != value))
				{
					this.OnColor1Changing(value);
					this.SendPropertyChanging();
					this._Color1 = value;
					this.SendPropertyChanged("Color1");
					this.OnColor1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Color_Car", Storage="_Cars", ThisKey="Id", OtherKey="IdColor")]
		public EntitySet<Car> Cars
		{
			get
			{
				return this._Cars;
			}
			set
			{
				this._Cars.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.Color = this;
		}
		
		private void detach_Cars(Car entity)
		{
			this.SendPropertyChanging();
			entity.Color = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Rentals")]
	public partial class Rental : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _IdClient;
		
		private int _IdCar;
		
		private System.DateTime _DateStart;
		
		private int _Duration;
		
		private EntityRef<Car> _Car;
		
		private EntityRef<Client> _Client;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnIdClientChanging(int value);
    partial void OnIdClientChanged();
    partial void OnIdCarChanging(int value);
    partial void OnIdCarChanged();
    partial void OnDateStartChanging(System.DateTime value);
    partial void OnDateStartChanged();
    partial void OnDurationChanging(int value);
    partial void OnDurationChanged();
    #endregion
		
		public Rental()
		{
			this._Car = default(EntityRef<Car>);
			this._Client = default(EntityRef<Client>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdClient", DbType="Int NOT NULL")]
		public int IdClient
		{
			get
			{
				return this._IdClient;
			}
			set
			{
				if ((this._IdClient != value))
				{
					if (this._Client.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdClientChanging(value);
					this.SendPropertyChanging();
					this._IdClient = value;
					this.SendPropertyChanged("IdClient");
					this.OnIdClientChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdCar", DbType="Int NOT NULL")]
		public int IdCar
		{
			get
			{
				return this._IdCar;
			}
			set
			{
				if ((this._IdCar != value))
				{
					if (this._Car.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdCarChanging(value);
					this.SendPropertyChanging();
					this._IdCar = value;
					this.SendPropertyChanged("IdCar");
					this.OnIdCarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateStart", DbType="Date NOT NULL")]
		public System.DateTime DateStart
		{
			get
			{
				return this._DateStart;
			}
			set
			{
				if ((this._DateStart != value))
				{
					this.OnDateStartChanging(value);
					this.SendPropertyChanging();
					this._DateStart = value;
					this.SendPropertyChanged("DateStart");
					this.OnDateStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Duration", DbType="Int NOT NULL")]
		public int Duration
		{
			get
			{
				return this._Duration;
			}
			set
			{
				if ((this._Duration != value))
				{
					this.OnDurationChanging(value);
					this.SendPropertyChanging();
					this._Duration = value;
					this.SendPropertyChanged("Duration");
					this.OnDurationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Car_Rental", Storage="_Car", ThisKey="IdCar", OtherKey="Id", IsForeignKey=true)]
		public Car Car
		{
			get
			{
				return this._Car.Entity;
			}
			set
			{
				Car previousValue = this._Car.Entity;
				if (((previousValue != value) 
							|| (this._Car.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Car.Entity = null;
						previousValue.Rentals.Remove(this);
					}
					this._Car.Entity = value;
					if ((value != null))
					{
						value.Rentals.Add(this);
						this._IdCar = value.Id;
					}
					else
					{
						this._IdCar = default(int);
					}
					this.SendPropertyChanged("Car");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Client_Rental", Storage="_Client", ThisKey="IdClient", OtherKey="Id", IsForeignKey=true)]
		public Client Client
		{
			get
			{
				return this._Client.Entity;
			}
			set
			{
				Client previousValue = this._Client.Entity;
				if (((previousValue != value) 
							|| (this._Client.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Client.Entity = null;
						previousValue.Rentals.Remove(this);
					}
					this._Client.Entity = value;
					if ((value != null))
					{
						value.Rentals.Add(this);
						this._IdClient = value.Id;
					}
					else
					{
						this._IdClient = default(int);
					}
					this.SendPropertyChanged("Client");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
