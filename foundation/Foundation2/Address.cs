using System;

public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrP, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrP;
        _country = country;
    }

    public bool IsInUSA()
    {
        if (_country.ToLower() == "usa")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string GetFullAddress()
    {
        if (string.IsNullOrEmpty(_stateOrProvince))
        {
            return $"{_streetAddress}\n{_city}\n{_country}";
        }
        else
        {
            return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
        }
    }
}