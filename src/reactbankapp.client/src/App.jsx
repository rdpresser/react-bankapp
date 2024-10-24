import Home from './components/Home';
import Customer from './components/Customer';
import Account from './components/Account';
import Loan from './components/Loan';
import Transaction from './components/Transaction';

import './App.css';

import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/customer" element={<Customer />} />
                <Route path="/account" element={<Account />} />
                <Route path="/loan" element={<Loan />} />
                <Route path="/transaction" element={<Transaction />} />
            </Routes>
        </Router>
    );
}

export default App