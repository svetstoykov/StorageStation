import "./App.css";
import { store, history } from "../../store";
import { Provider } from "react-redux";
import { HistoryRouter as Router } from "redux-first-history/rr6";
import { Route, Routes } from "react-router-dom";
import LoginPage from "../features/login/components/LoginPage";
import MainLayout from "./MainLayout";

function App() {

    return (
        <Provider store={store}>
            <Router history={history}>
                <Routes>
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/*" element={<MainLayout/>} />
                </Routes>
            </Router>
        </Provider>
    );
}

export default App;
