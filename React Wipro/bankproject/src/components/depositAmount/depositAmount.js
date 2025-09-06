import axios from 'axios';
import React, {Component, useState} from 'react';

const Deposit = () => {
      const [result,SetResult] = useState('');
       const [data, setData] = useState({
          accountNo : 0,
          depositAmount : 0,
      })
  
     const handleChange = event => {
        setData({
            ...data,[event.target.name] : event.target.value  
        })
    }

    const depositAccount = () => {
     axios.post("https://localhost:7182/deposit/"+data.accountNo + "/"+data.depositAmount).then(resp => {
        //   alert(resp.data);
        SetResult(resp.data);
          console.log(resp.data);
        })
    }

      return (
        <div className="component-container">
            <div className="component-header">Deposit Amount</div>
            
            <div className="form-group">
                <label>Account No : </label>
                <input type="number" name="accountNo" 
                    value={data.accountNo} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>Deposit Amount : </label>
                <input type="number" name="depositAmount" 
                    value={data.depositAmount} onChange={handleChange} />
            </div>
 
            <input type="button" className="btn" value="Deposit Amount" onClick={depositAccount} />
            
            {result && <div className="result-message">{result}</div>}
        </div>
      )

}

export default Deposit;