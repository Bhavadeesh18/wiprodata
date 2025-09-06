import React, {Component} from 'react';
import Menu from '../menu/menu';const Third = (props) => {
    return (
        <div>
            
            First Name is: <b>{props.firstname}</b> <br/>
            Last Name is: <b>{props.lastname}</b> <br/>
            Company is: <b>{props.company}</b> <br/>
        </div>
    );
};

export default Third;