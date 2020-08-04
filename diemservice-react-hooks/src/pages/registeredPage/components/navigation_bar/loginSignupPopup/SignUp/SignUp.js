import React, {useState} from 'react';
import styles from './SignUp.module.scss';
import useCustomForm from '../../../../../../utils/useCustomForm';

export default function SignUp(props) {

    const SignMeUp = (values) =>{
        console.log(values)
        props.finished()
    }
   const {
       values,
       errors,
       handleChange,
       handleSubmit
   }
   = useCustomForm({initialValues: {},onSubmit : SignMeUp});
    


    return (
            <form onSubmit = {handleSubmit}>
        <div className = {styles.field_container}>
                <label>
                    Name
                </label>
                <input name = "Name" onChange = {handleChange} type = "text"/> 
                <label>
                    Last Name
                </label>
                <input name = "LastName" onChange = {handleChange} type = "text"/>
                <label>
                    Address
                </label>
                <input name = "Address" onChange = {handleChange} type = "text"/>
                <input className= {styles.button} value = "Sign Up" type = "submit" />
        </div>
            </form>
    )
}
