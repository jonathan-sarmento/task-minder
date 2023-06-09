export class Login {

    FazerLogin(){
        cy.visit('http://localhost:5000/');

        cy.get('input#LoginInput_UserNameOrEmailAddress').type('ui-test');
        cy.get('input#LoginInput_Password').type('@Uitest123');
        cy.get('button[value="Login"]').click();

        cy.wait(3000);
    }

}