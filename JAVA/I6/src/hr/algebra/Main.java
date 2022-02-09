/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package hr.algebra;

import hr.algebra.models.TravelWarrant;
import hr.algebra.utils.PDFMaker;
import java.util.ArrayList;
import java.util.List;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;

/**
 *
 * @author pasar
 */
public class Main {

    public static void main(String[] args) {
        try {
            List<TravelWarrant> warrants = new ArrayList<>();
            EntityManagerFactory emf = Persistence.createEntityManagerFactory("I6PU");
            EntityManager em = emf.createEntityManager();
            
            em.getTransaction().begin();
            
            Query query = em.createNativeQuery("select * from TravelWarrant", TravelWarrant.class);
            query.getResultList().forEach(System.out::println);
            query.getResultList().forEach(result -> warrants.add((TravelWarrant)result));
            em.getTransaction().commit();
            
            PDFMaker.createPDF(warrants);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
