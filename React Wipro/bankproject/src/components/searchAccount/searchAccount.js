import axios from 'axios';
import React, {Component, useState} from 'react';

const SearchAccount = () => {
    const[accountResult, SetAccountResult] = useState({})
    const[accountNo,SetAccountNo] = useState(0) 

     const handleChange = event => {
        SetAccountNo(event.target.value)
        // alert(empno);
    }

    const show = () => {
        // alert(userId)
        let accno = parseInt(accountNo);
        axios.get("https://localhost:7182/api/BankCustom/"+accno).then(
            (response) => {
                SetAccountResult(response.data)
            }  
          )
    }

    return (
      <div className="component-container">
        <div className="component-header">Search Account</div>
        
        <div className="form-group">
            <label>Account No : </label>
            <input type="number" name="accountNo" 
                value={accountNo} onChange={handleChange} />
        </div>
        
        <input type="button" className="btn" value="Search" onClick={show} />
        
        {accountResult.accountNo && (
            <div className="result-message">
                <div><strong>Account No:</strong> {accountResult.accountNo}</div>
                <div><strong>First Name:</strong> {accountResult.firstName}</div>
                <div><strong>Last Name:</strong> {accountResult.lastName}</div>
                <div><strong>City:</strong> {accountResult.city}</div>
                <div><strong>State:</strong> {accountResult.state}</div>
                <div><strong>Amount:</strong> ₹{accountResult.amount}</div>
                <div><strong>Cheq Facility:</strong> {accountResult.cheqFacil}</div>
                <div><strong>Account Type:</strong> {accountResult.accountType}</div>
            </div>
        )}
      </div>
    )

}

export default SearchAccount;