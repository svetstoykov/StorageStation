import { Fragment } from "react";
import { Routes, Route } from "react-router-dom";
import NavBar from './NavBar'
import HomePage from '../features/home/components/HomePage'
import SideMenuDrawer from '../features/home/components/SideMenuDrawer'

function MainLayout(){
    return (
        <Fragment>
            <NavBar/>
            <Routes>
                <Route path='/' element={<HomePage/>}/>
                <Route path='/sidebar' element={<SideMenuDrawer/>}/>
            </Routes>
        </Fragment>
    )
}

export default MainLayout;