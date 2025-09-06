import axios from 'axios';
import React, {Component, useEffect, useState} from 'react';

const ShowAccount = () => {
  const[accounts,setAccountData] = useState([])

 useEffect(() => {
    const fetchData = async () => {
      const response = await 
        axios.get("https://localhost:7182/api/BankCustom/");
        setAccountData(response.data)
    }
    fetchData();
  },[])
  return (
    <div className="component-container">
      <div className="component-header">All Accounts</div>
      
      <table className="styled-table">
        <thead>
          <tr>
            <th>Account No</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>City</th>
            <th>State</th>
            <th>Amount</th>
            <th>Cheq Facil</th>
            <th>Account Type</th>
          </tr>
        </thead>
        <tbody>
          {accounts.map((item, index) => 
            <tr key={index}>
              <td>{item.accountNo}</td>
              <td>{item.firstName}</td>
              <td>{item.lastName}</td>
              <td>{item.city}</td>
              <td>{item.state}</td>
              <td>₹{item.amount}</td>
              <td>{item.cheqFacil}</td>
              <td>{item.accountType}</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  )
}

export default ShowAccount;