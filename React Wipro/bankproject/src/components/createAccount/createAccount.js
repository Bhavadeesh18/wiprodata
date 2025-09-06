import axios from 'axios';
import React, {Component, useState} from 'react';
const CreateAccount = () => {
      const[result,setResult] = useState('')
      const [data, setData] = useState({
        firstName : '',
        lastName : '',
        city : '',
        state : '',
        amount : 0,
        cheqcheqFacil:'',
        accountType:''
    })

    const createAccount = () => {
      axios.post("https://localhost:7182/api/BankCustom",{
          firstName : data.firstName,
          lastName : data.lastName,
          city : data.city,
          state : data.state,
          amount : data.amount, 
          cheqFacil : data.cheqFacil,
          accountType : data.accountType 
        }).then(resp => {
          //  alert(resp.data);
          setResult(resp.data);
          console.log(resp.data);
        })

    }

    const handleChange = event => 
    {
        setData({
            ...data,[event.target.name] : event.target.value  
        })
    }

      return (
        <div className="component-container">
            <div className="component-header">Create New Account</div>
            
            <div className="form-group">
                <label>First Name : </label>
                <input type="text" name="firstName" 
                    value={data.firstName} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>Last Name : </label>
                <input type="text" name="lastName" 
                    value={data.lastName} onChange={handleChange} />
            </div>

            <div className="form-group">
                <label>City : </label>
                <input type="text" name="city" 
                    value={data.city} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>State : </label>
                <input type="text" name="state" 
                    value={data.state} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>Amount : </label>
                <input type="number" name="amount" 
                    value={data.amount} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>Cheq Facil : </label>
                <input type="text" name="cheqFacil" 
                    value={data.cheqFacil} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>Account Type : </label>
                <input type="text" name="accountType" 
                    value={data.accountType} onChange={handleChange} />
            </div>
            
            <input type="button" className="btn" value="Create Account" onClick={createAccount} />
            
            {result && <div className="result-message">{result}</div>}
        </div>
      )

}

export default CreateAccount;