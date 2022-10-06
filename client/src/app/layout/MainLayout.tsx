import { Fragment } from "react";
import { Routes, Route } from "react-router-dom";
import NavBar from './shared/NavBar'
import HomePage from '../features/home/components/HomePage'

function MainLayout(){
    return (
        <Fragment>
            <NavBar/>
            <Routes>
                <Route path='/' element={<HomePage/>}/>
            </Routes>
        </Fragment>
    )
}

export default MainLayout;