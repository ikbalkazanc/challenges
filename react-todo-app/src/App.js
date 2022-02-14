import Header from './pages/layout/header'
import Footer from './pages/layout/footer'
import MainPage from './pages/MainPage';
import { Container } from 'react-bootstrap';
import store from './store';
import { Provider } from 'react-redux';

function App() {
  return (
    <div >
      <Provider store={store}>
        <Header number="10" />
        <Container>
          <MainPage />
        </Container>
        <Footer /></Provider>
    </div>
  );
}

export default App;
