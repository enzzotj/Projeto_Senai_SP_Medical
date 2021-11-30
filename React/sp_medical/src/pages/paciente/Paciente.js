import { Component } from "react";
import './estilo.css'
import Logo from '../img/logo1.png'

class Paciente extends Component {

    constructor(props) {
        super(props);
        this.state = {
            listaPaciente: [],
            titulo: '',

        };
    };


    BuscarPaciente = () => {
        console.log("Chamar Api")

        fetch('http://localhost:5000/api/Consultas')

            .then(resposta => resposta.json())

            .then(dados => this.setState({ listaPaciente: dados }))

            .catch(erro => console.log(erro))
    }


    componentDidMount() {
        this.BuscarPaciente()
    }

    render() {

        return (

            <div className="container_fundotab">

                <header>
                    <div class="container container_header">

                        {/* <img className="logo" src={Logo} alt="logo"> */}
                        {/* <Logo className="logo" alt="logo"/> */}
                        <div className ="container_final_header">
                        <h1>Medico</h1>
                        {/* <input className ="img_sair" type ="image" src="img/SairBranco.png" alt="Sair"> */}
                        </div>
                    </div>
                </header>

                <main>
                    <div className="container_centralizar">
                    <section className="container_tab">
                        <table className="">

                            <thead>
                                <tr>

                                    <th>Nome</th>
                                    <th>Nome Medico</th>
                                    <th>Descriçao</th>
                                    <th>Situaçao</th>
                                    <th>Data</th>

                                </tr>

                            </thead>

                            <tbody>

                                {
                                    this.state.listaPaciente.map((listaPaciente) => {
                                        return (
                                            <tr key={listaPaciente.idConsulta}>
                                                <td>{listaPaciente.nomePaciente}</td>
                                                <td>{listaPaciente.nomeMedico}</td>
                                                <td>{listaPaciente.descricao}</td>
                                                <td>{listaPaciente.situacao}</td>
                                                <td>{listaPaciente.dataConsulta}</td>
                                            </tr>
                                        )
                                    }

                                    )
                                }

                            </tbody>

                        </table>

                    </section>
                    </div>
                </main>

            </div>
        )
    }

};

export default Paciente;