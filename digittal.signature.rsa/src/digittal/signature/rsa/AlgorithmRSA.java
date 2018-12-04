package digittal.signature.rsa;

//package atnf.atoms.mon.util;
import java.math.BigInteger;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;

public class AlgorithmRSA {

    private BigInteger n, d, e;

    public BigInteger getN() {
        return n;
    }

    public void setN(BigInteger n) {
        this.n = n;
    }

    public BigInteger getD() {
        return d;
    }

    public void setD(BigInteger d) {
        this.d = d;
    }

    public BigInteger getE() {
        return e;
    }

    public void setE(BigInteger e) {
        this.e = e;
    }

    /**
     * Create an instance that can encrypt using someone elses public key.
     */
    public AlgorithmRSA(BigInteger newn, BigInteger newe) {
        n = newn;
        e = newe;
    }

    /**
     * Create an instance that can both encrypt and decrypt.
     */
    public AlgorithmRSA() {
        
       
    }
    
    public void KeyRSA(int bits){
         SecureRandom r = new SecureRandom();
        BigInteger p = new BigInteger(bits / 2, 100, r);
        BigInteger q = new BigInteger(bits / 2, 100, r);
        n = p.multiply(q);
        BigInteger m = (p.subtract(BigInteger.ONE)).multiply(q
                .subtract(BigInteger.ONE));
        boolean found = false;
        do {
            e = new BigInteger(bits / 2, 50, r);
            if (m.gcd(e).equals(BigInteger.ONE) && e.compareTo(m) < 0) {
                found = true;
            }
        } while (!found);
        d = e.modInverse(m);
        
    }

    /**
     * Encrypt the given plaintext message.
     */
    public synchronized String encrypt(String message) {
        return (new BigInteger(message.getBytes())).modPow(d, n).toString();
    }

    /**
     * Encrypt the given plaintext message.
     */
    public synchronized BigInteger encrypt(BigInteger message) {
        return message.modPow(d, n);
    }

    /**
     * Decrypt the given ciphertext message.
     */
    public synchronized String decrypt(String message) {
        return new String((new BigInteger(message)).modPow(e, n).toByteArray());
    }

    /**
     * Decrypt the given ciphertext message.
     */
    public synchronized BigInteger decrypt(BigInteger message) {
        return message.modPow(e, n);
    }

    /**
     * Trivial test program.
     */
    public static void main(String[] args) throws Exception {
//        AlgorithmRSA rsa = new AlgorithmRSA(1024);

//  String text1 = "61411052594266198945160928231491351478092641952090802072832725103112401723238872475837656358211754090171851111212828049142487895150211281946584341673611260981476781237054294943964606351346418570018386162397306369277957453253895691207103085117377771127143971893413119023558926066781433174850559335024822557544";
//        SHA1 sha1 = new SHA1();
//
//        String bi = new String(sha1.md("show.png").toString());
//        BigInteger text1 = new BigInteger(bi);
//        System.out.println("Plaintext: " + text1);
////  BigInteger plaintext = new BigInteger(text1);
//
//        BigInteger ciphertext = rsa.encrypt(text1);
//        System.out.println("Ciphertext: " + ciphertext);
////  plaintext = rsa.decrypt(ciphertext);
//
//        BigInteger text2 = rsa.decrypt(ciphertext);
//        System.out.println("Plaintext: " + text2);
    }

    void setN(int bitleg) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
