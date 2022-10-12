import { Fragment } from "react";
import { Routes, Route, useLocation } from "react-router-dom";
import NavBar from "./shared/NavBar";
import HomePage from "../features/home/HomePage";
import StoredItemsList from "../features/storedItems/StoredItemsList";
import Box from "@mui/material/Box";
import { motion } from "framer-motion";

function MainLayout() {
    const { pathname } = useLocation();

    return (
        <Fragment>
            <NavBar />
            <Box sx={{ width: "100%", bgcolor: "background.paper" }}>
                <nav aria-label="main mailbox folders">
                    <motion.div
                        initial={{ opacity: 0 }}
                        animate={{ opacity: 1 }}
                        exit={{ opacity: 0 }}
                        transition={{ duration: 0.5 }}
                        key={pathname}
                    >
                        <Routes>
                            <Route path="/" element={<HomePage />} />
                            <Route path="/storedItems" element={<StoredItemsList />} />
                        </Routes>
                    </motion.div>
                </nav>
            </Box>
        </Fragment>
    );
}

export default MainLayout;
