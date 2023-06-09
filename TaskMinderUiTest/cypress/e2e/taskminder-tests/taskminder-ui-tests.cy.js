/// <reference types="cypress" />

import { faker } from '@faker-js/faker';
import { Login } from "../../support/Login";
import "cypress-real-events";

var loginPage = new Login();

context('Takminder Main Page', () => {
    beforeEach(() => {
        loginPage.FazerLogin();
    });

    it.only('Validar cadastro de cards', () => {
        let numeroEntradas = 3;

        for (let index = 0; index < numeroEntradas; index++) {
            
            // Clilca no botão de criar novo
            cy.get('a[data-testid="accordion-button"]').click({force: true});
            cy.wait(250);
          
            // Cadastra um novo todo
            cy.get('form [data-testid="title-input"]').type(faker.lorem.words(2));
            cy.get('form [data-testid="description-input"]').type(faker.lorem.words(3));
            cy.get('form [data-testid="submit-button"]').click();
            
        }
        cy.get('[data-testid="todo-item"]').should('have.length.gte', numeroEntradas);

    });

    it('Validar exclusão de cards', () => {
        let numeroExclusao = 2;

        let quantidadeInicialElementos = 0;

        cy.get('[data-testid="todo-item"]').its('length').then((length) => {
            quantidadeInicialElementos = length;
            cy.log(quantidadeInicialElementos);
            return 133;
        });
        


        for (let index = 0; index < numeroExclusao; index++) {
            // cy.get('[data-testid="todo-item"]').realHover("mouse");
            // cy.wait(100);
            cy.get('[data-testid="delete-button"]').first().realHover("mouse").click();
            cy.wait(1000);
            cy.get('[data-testid="submit-buttons"] button.btn-primary').click();
            cy.wait(500);
        }


        cy.get('[data-testid="todo-item"]').should('have.length', quantidadeInicialElementos - numeroExclusao);
    });
});